using System;
using System.IO;
using System.Collections;

namespace Module2HW5.Helpers
{
    public class FileComparer : IComparer
    {
        public int Compare(object first, object second)
        {
            var firstFile = first as string;
            var secondFile = second as string;

            if (firstFile == null || secondFile == null)
            {
                return 0;
            }

            var firstFileInfo = new FileInfo(firstFile);
            var secondFileInfo = new FileInfo(secondFile);

            return DateTime.Compare(firstFileInfo.CreationTime, secondFileInfo.CreationTime);
        }
    }
}