using System.Collections.Generic;

namespace FakeItEasySuccinctly.Chapter8Arguments.PassingArgumentsToMethods.ADummy
{
    public class Result
    {
        public Result()
        {
            this.ErrorMessages = new List<string>();
        }
        
        public List<string> ErrorMessages;
    }
}