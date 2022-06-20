using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace ECommerceLiveDemo.Models
{
    public partial class User
    {
        public User()
        {
            UserUserRoleMappings = new HashSet<UserUserRoleMapping>();
        }

        public int Id { get; set; }
        //[DisplayName("User Name")]
        //public string UserName { get; set; }
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Isim")]
        public string FirstName { get; set; }
        [DisplayName("SoyIsım")]
        public string LastName { get; set; }
        [DisplayName("Doğum Tarihi")]
        public DateTime? BirthDate { get; set; }
        [DisplayName("Cinsiyet")]
        public string Gender { get; set; }
        [DisplayName("Telefon Numarası")]
        public string MobilePhoneNo { get; set; }
        [DisplayName("Kayıt Tarihi")]
        public DateTime? CreateDate { get; set; }
        [DisplayName("Güncelleme Tarihi")]
        public DateTime? UpdateDate { get; set; }
        public DateTime? LastSignOnDate { get; set; }

        public virtual ICollection<UserUserRoleMapping> UserUserRoleMappings { get; set; }
        public virtual ICollection<BrandUserMapping> BrandUserMappings { get; set; }
    }
}
