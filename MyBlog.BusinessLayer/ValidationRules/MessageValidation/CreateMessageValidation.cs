using FluentValidation;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.ValidationRules.MessageValidation
{
    public class CreateMessageValidation: AbstractValidator<Message>
    {
        public CreateMessageValidation()
        {
            RuleFor(x => x.Alıcı).NotEmpty().WithMessage("Alıcı Mail Adresini Boş Geçemezsiniz");
            RuleFor(x => x.Gonderen).NotEmpty().WithMessage("Gönderen Mail Adresini Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu Adını Boş Geçemezsiniz");
            RuleFor(x => x.MessageDescription).NotEmpty().WithMessage("Mesajı Boş Geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.MessageDescription).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapın");

        }
    }
}
