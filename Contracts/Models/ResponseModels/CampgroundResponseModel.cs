﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Models.ResponseModels
{
    public class CampgroundResponseModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public List<ImagesResponseModel> Images { get; set; }

        public List<CommentResponseModel> Comments { get; set; }
    }
}
