﻿using System;
using Dapper.Contrib.Extensions;

namespace Lending.ReadModels.Relational.LibraryOpened
{
    [Table("\"OpenedLibrary\"")]
    public class OpenedLibrary
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string AdministratorId { get; protected set; }
        public virtual string AdministratorPicture { get; set; }

        public OpenedLibrary(Guid id, string name, string administratorId, string administratorPicture)
        {
            Id = id;
            Name = name;
            AdministratorId = administratorId;
            AdministratorPicture = administratorPicture;
            if (administratorPicture == null) AdministratorPicture = string.Empty;
        }

        protected OpenedLibrary()
        {
            AdministratorPicture=String.Empty;
        }
    }
}
