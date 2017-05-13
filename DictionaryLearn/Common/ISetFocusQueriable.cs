using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryLearn.Common
{
    //-------------------------------------------------------------------------------------------------------------------
    // class ISetFocusQueriable
    //-------------------------------------------------------------------------------------------------------------------
    public interface ISetFocusQueriable
    {
        event Action QuerySetFocus;
    }
    //-------------------------------------------------------------------------------------------------------------------
}
