using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GCoreApp.DependancyServices
{
    public interface IPGMImageService
    {
        MemoryStream GetMedia();
    }
}
