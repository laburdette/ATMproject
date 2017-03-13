using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace week7projectATM

{
    public abstract class BaseATM
    {
        //declare fields

        public string AccountNumber { get; set; }



        //constructors
        public BaseATM(string accountNumber)
        {
            AccountNumber = accountNumber;
        }
        

        //methods

    }
   


}//end of base
    

