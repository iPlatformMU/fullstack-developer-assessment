namespace FoursquareTest.Models
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class rsp
    {

        private rspPhotos photosField;

        private string statField;

        /// <remarks/>
        public rspPhotos photos
        {
            get
            {
                return this.photosField;
            }
            set
            {
                this.photosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string stat
        {
            get
            {
                return this.statField;
            }
            set
            {
                this.statField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rspPhotos
    {

        private rspPhotosPhoto[] photoField;

        private byte pageField;

        private ushort pagesField;

        private byte perpageField;

        private uint totalField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("photo")]
        public rspPhotosPhoto[] photo
        {
            get
            {
                return this.photoField;
            }
            set
            {
                this.photoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte page
        {
            get
            {
                return this.pageField;
            }
            set
            {
                this.pageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort pages
        {
            get
            {
                return this.pagesField;
            }
            set
            {
                this.pagesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte perpage
        {
            get
            {
                return this.perpageField;
            }
            set
            {
                this.perpageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint total
        {
            get
            {
                return this.totalField;
            }
            set
            {
                this.totalField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rspPhotosPhoto
    {

        private ulong idField;

        private string ownerField;

        private string secretField;

        private ushort serverField;

        private byte farmField;

        private string titleField;

        private byte ispublicField;

        private byte isfriendField;

        private byte isfamilyField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string owner
        {
            get
            {
                return this.ownerField;
            }
            set
            {
                this.ownerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string secret
        {
            get
            {
                return this.secretField;
            }
            set
            {
                this.secretField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort server
        {
            get
            {
                return this.serverField;
            }
            set
            {
                this.serverField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte farm
        {
            get
            {
                return this.farmField;
            }
            set
            {
                this.farmField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ispublic
        {
            get
            {
                return this.ispublicField;
            }
            set
            {
                this.ispublicField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte isfriend
        {
            get
            {
                return this.isfriendField;
            }
            set
            {
                this.isfriendField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte isfamily
        {
            get
            {
                return this.isfamilyField;
            }
            set
            {
                this.isfamilyField = value;
            }
        }
    }



}
