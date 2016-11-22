using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using TestWeb.Model;

namespace TestWeb
{
	public partial class _Default : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (this.IsPostBack)
            //    GetInput();
        }

        protected static void ValidateInput(Input input) {  
            //var input = new Input();
            var context = new ValidationContext(input, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(input, context, results);

            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }
        }

        [System.Web.Services.WebMethod]
        public static void getformData(List<string> formData)
        {
            Input input = new Input();
            input.Name = formData[0];
            input.FavoriteColor = (Color)Enum.Parse(typeof(Color), formData[1]);
            input.Over18 = (bool)Boolean.Parse(formData[2]);
            if(formData[3]!=null)
                input.FavoriteTime = (TimeOfDay)Enum.Parse(typeof(TimeOfDay),formData[3]);

            ValidateInput(input);
        }
    }

}
