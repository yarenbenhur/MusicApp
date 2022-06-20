using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business
{
    public abstract class BaseContext
    {
        protected string FilePath { get; set; }

        public BaseContext(string fileName)
        {
            FilePath = FileOperations.BasePath + fileName;
            FileOperations.CreateFile(FilePath);
        }
    }
}
