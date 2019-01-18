using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIQueryLibrary
{
    /// <summary>
    /// 참고: https://www.iana.org/assignments/media-types/media-types.xhtml
    /// </summary>
    public enum MediaTypes
    {
        /// <summary xml:lang="kr"></summary>
        /// <summary xml:lang="en"></summary>   
        form_data,

        /// <summary xml:lang="kr"></summary>
        /// <summary xml:lang="en"></summary>
        x_www_form_urlencoded,

        /// <summary xml:lang="kr"></summary>
        /// <summary xml:lang="en"></summary>
        raw,

        /// <summary xml:lang="kr"></summary>
        /// <summary xml:lang="en"></summary>
        binary
    }
}
