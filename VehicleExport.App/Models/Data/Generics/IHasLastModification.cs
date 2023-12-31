﻿using System;

namespace VehicleExport.App.Models.Data
{
    public interface IHasLastModification
    {
        DateTime LastModification { get; set; }
        Guid LastModificationApplicationUserId { get; set; }
    }
}
