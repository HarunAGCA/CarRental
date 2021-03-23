using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
   public static class BusinessEngine
    {
        public static IResult Run(params IResult[] logicResults)
        {
            foreach (var result in logicResults)
            {
                if (!result.IsSuccess)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
