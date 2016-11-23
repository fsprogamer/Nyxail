using System;
using System.Web.UI;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using TestWeb.Model;

namespace TestWeb
{
	public partial class _Default : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected static bool ValidateInput(Input input, ref List<ValidationResult> results) {  

            var context = new ValidationContext(input, serviceProvider: null, items: null);
            var isValid = Validator.TryValidateObject(input, context, results, true);

            return isValid;
        }

        [System.Web.Services.WebMethod]
        public static Input getformData(List<string> formData)
        {
            Input input = new Input();
            input.Name = formData[0];
            input.FavoriteColor = (Color)Enum.Parse(typeof(Color), formData[1]);
            input.Over18 = (bool)Boolean.Parse(formData[2]);
            if (formData[3] != null)
                input.FavoriteTime = (TimeOfDay)Enum.Parse(typeof(TimeOfDay), formData[3]);
            else
                input.FavoriteTime = TimeOfDay.Undefined;

            var results = new List<ValidationResult>();
            if (ValidateInput(input, ref results) == false)
            {
                string ErrMess = String.Empty;
                foreach(ValidationResult val in results)
                {
                    ErrMess += val.ErrorMessage + "<br>";
                }
                throw new Exception(ErrMess);
            }

            return input;
        }
    }

}
