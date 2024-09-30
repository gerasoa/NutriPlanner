﻿using CCRS.Core.Data;
using FluentValidation.Results;
using System.Net.Http.Headers;


namespace CCRS.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;
       
        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AdddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }
        
        protected async Task<ValidationResult> SaveData(IUnifOfWork uow)
        {
            //todo try-catch do commit
            try
            {
                if (!await uow.Commit()) AdddError("An error occurred during data persistence.");
            }
            catch (Exception  ex)
            {
                throw;
            }
            
            return ValidationResult;
        }
    }
}
