using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShortLink.DataLayer.Entites
{
    public class GenerateLink
    {

        #region Propertise

        [Key]
        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [MaxLength(250, ErrorMessage = "طول فیلید {0} باید حداکثر {1} باشد")]
        public string Title { get; set; }


        [Display(Name = "لینک")]
        [Required(ErrorMessage = "فیلد {0} اجباری می باشد")]
        [MaxLength(250, ErrorMessage = "طول فیلید {0} باید حداکثر {1} باشد")]
        public string Link { get; set; }




        public string ShortLink { get; set; }

        public DateTime CreateDate { get; set; }

        #endregion

    }
}
