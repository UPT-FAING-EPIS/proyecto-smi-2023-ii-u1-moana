using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moana.Models
{
    public interface IImageSaver
    {
        Task<string> SaveImageToDisk(Stream imageStream, string fileName);
    }
}
