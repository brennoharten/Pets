using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Pets.Domain.Enums;
using Pets.Domain.Notifications;
using Pets.Domain.ValueObjects;

namespace Pets.Domain.Validations
{
    public partial class ContractValidation<T>
    {
        public ContractValidation<T> DocumentIsOk(Document document, string message, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(document.DocumentNumber))
            {
                AddNotification(new Notification(message, propertyName));
                return this;
            }

            var digitsOnly = Regex.Replace(document.DocumentNumber, @"[^\d]", "");

            bool isValid = document.DocumentType switch
            {
                EDocumentType.CPF => IsValidCpf(digitsOnly),
                EDocumentType.CNPJ => IsValidCnpj(digitsOnly),
                _ => false
            };

            if (!isValid)
                AddNotification(new Notification(message, propertyName));

            return this;
        }


        private static bool IsValidCpf(string cpf)
        {
            if (cpf.Length != 11 || Regex.IsMatch(cpf, @"^(\d)\1{10}$"))
                return false;

            var tempCpf = cpf.Substring(0, 9);
            var firstDigit = CalculateCpfDigit(tempCpf, new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 });
            var secondDigit = CalculateCpfDigit(tempCpf + firstDigit, new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 });

            return cpf.EndsWith($"{firstDigit}{secondDigit}");
        }

        private static int CalculateCpfDigit(string baseCpf, int[] weights)
        {
            int sum = 0;
            for (int i = 0; i < weights.Length; i++)
                sum += (baseCpf[i] - '0') * weights[i];

            int remainder = sum % 11;
            return remainder < 2 ? 0 : 11 - remainder;
        }

        private static bool IsValidCnpj(string cnpj)
        {
            if (cnpj.Length != 14 || Regex.IsMatch(cnpj, @"^(\d)\1{13}$"))
                return false;

            var tempCnpj = cnpj.Substring(0, 12);
            var firstDigit = CalculateCnpjDigit(tempCnpj, new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });
            var secondDigit = CalculateCnpjDigit(tempCnpj + firstDigit, new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });

            return cnpj.EndsWith($"{firstDigit}{secondDigit}");
        }

        private static int CalculateCnpjDigit(string baseCnpj, int[] weights)
        {
            int sum = 0;
            for (int i = 0; i < weights.Length; i++)
                sum += (baseCnpj[i] - '0') * weights[i];

            int remainder = sum % 11;
            return remainder < 2 ? 0 : 11 - remainder;
        }
    }
}