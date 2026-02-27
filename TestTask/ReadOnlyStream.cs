using System;
using System.IO;
using System.Text;

namespace TestTask
{
    public class ReadOnlyStream : IReadOnlyStream
    {
        private StreamReader _localStream;

        /// <summary>
        /// Конструктор класса. 
        /// </summary>
        /// <param name="fileFullPath">Полный путь до файла для чтения</param>
        public ReadOnlyStream(string fileFullPath)
        {
            var fileStream = File.Open(fileFullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            _localStream = new StreamReader(fileStream, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: true);
            if(_localStream == null)
                throw new EndOfStreamException();
        }

        /// <summary>
        /// Флаг окончания файла.
        /// </summary>
        public bool IsEof => _localStream == null || _localStream.EndOfStream;

        /// <summary>
        /// Ф-ция чтения следующего символа из потока.
        /// Если произведена попытка прочитать символ после достижения конца файла, метод 
        /// должен бросать соответствующее исключение
        /// </summary>
        /// <returns>Считанный символ.</returns>
        public char ReadNextChar()
        {
            try
            {
                 return (char)_localStream.Read();
            }
            catch (EndOfStreamException e)
            {
                throw new EndOfStreamException(e.Message);
            }
        }

        /// <summary>
        /// Сбрасывает текущую позицию потока на начало.
        /// </summary>
        public void ResetPositionToStart()
        {
            if (_localStream == null)
            {
                return;
            }

            _localStream.DiscardBufferedData();
            _localStream.BaseStream.Position = 0;
        }

        public void Dispose()
        {
            _localStream?.Dispose();
            _localStream = null;
        }
    }
}
