using System.IO;

namespace IronFE.Format
{
    public abstract class FileFormat
    {
        protected readonly Stream inFileStream;
        protected readonly string filePath;
        private readonly string formatName;

        public Stream BaseStream => inFileStream;

        public string FilePath => filePath;

        public string FormatName => formatName;

        protected FileFormat(string formatName, string filePath)
        {
            this.formatName = formatName;

            // Make sure we were given a sane path
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }
            else
            {
                FileInfo fileInfo = new(filePath);
                this.filePath = fileInfo.FullName;
            }

            inFileStream = File.OpenRead(filePath);
        }
    }
}
