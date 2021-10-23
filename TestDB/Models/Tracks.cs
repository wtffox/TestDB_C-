namespace TestDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tracks
    {
        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string name { get; set; }

        public int musician_id { get; set; }

        public int genre_id { get; set; }

        public int owner_id { get; set; }

        public virtual Genres Genres { get; set; }

        public virtual Musicians Musicians { get; set; }

        public virtual Users Users { get; set; }
    }
}
