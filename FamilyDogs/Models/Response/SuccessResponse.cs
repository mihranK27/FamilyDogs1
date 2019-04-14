using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyDogs.Models.Response
{
    public class SuccessResponse
    {
        bool IsSuccessful;

        public SuccessResponse()
        {
            this.IsSuccessful = true;
        }
    }
}