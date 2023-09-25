using System;
using System.Collections.Generic;

namespace VehicleExport.Web.ExternalServices.VSO.Models
{
    public class Dealer
    {
        public Dealer() {
            DealerId = 0;
            Name = String.Empty;
            LegalName = String.Empty;
            Address = String.Empty;
            Address2 = String.Empty;
            City = String.Empty;
            State = String.Empty;
            Zip = String.Empty;
            Country = "US";
            Phone = String.Empty;
            Fax = String.Empty;
            ContactName = String.Empty;
            ContactEmail = String.Empty;
            ContactName2 = String.Empty;
            ContactEmail2 = String.Empty;
            SalespersonId = 0;
            InventoryLimit = 0;
            Enabled = 1;
            UseVinDecode = 1;
            InternetId = 0;
            StickerCredits = 0;
            JMACredits = 0;
            AddendumCredits = 0;
            GMFields = String.Empty;
            LogoFile = String.Empty;
            GlobalNotes = String.Empty;
            DealershipNotes = String.Empty;
            BookValueNotes = "Book Value";
            PriceNotes = "Price";
            DiscountNotes = "Discount";
            FinalPriceNotes = "Our Price";
            NoPriceNotes = "Ask Salesperson For Details";
            CarfaxUserId = String.Empty;
            CarfaxPassword = String.Empty;
            CarfaxAutoPurchase = 0;
            ExperianId = String.Empty;
            PrintBarcode = 0;
            PrintQRBarcode = false;
            PrintLogo = 0;
            PrintVHLogo = 0;
            PrintBuyersGuide = 0;
            PrintPrice = 1;
            PrintAddPrice = 0;
            PrintPedigree = 0;
            AllowCarfax = 0;
            AllowExperian = 0;
            CopyPedigreeImage = 0;
            AutoUpload = 0;
            CopyPrice = 0;
            RDataSource = "U";
            HomepageContentId = 0;
            NADAPrices = 0; // 0-Off 1-On
            NADARegionDescription = String.Empty;
            NADARegionId = 0;
            AutoCopyNada = 0;

            DMSAutoSync = 0;
            DMSAutoUpdate = 1;
            NADAAutoSync = 0;
            NADAAutoUpdate = 1;

            AdCreator = 0;
            WebsiteUrl = String.Empty;

            AssociationId = 0;
            GroupId = 0;

            EnableDealerFrameParameterEditing = false;
            VendorImportEnrolled = false;
            VendorImportEnabled = false;
            VendorImportVendorName = String.Empty;
            VendorImportFileName = String.Empty;
            VendorImportFull = false;
            VendorImportLastImportReceived = Convert.ToDateTime("1/1/1900");
            VendorImportEquipFiltering = false;

            DisableDataExport = false;

            AllowInventoryPurge = false;
            InventoryPurgeFrequency = 0;
            InventoryPurgeAuto = false;

            EnableEnhancedData = false;

        }

		public int DealerId { get; set; }
		public string Name { get; set; }
		public string LegalName { get; set; }
		public string Address { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string Country { get; set; }
		public string Phone { get; set; }
		public string Fax { get; set; }
		public string ContactName { get; set; }
		public string ContactEmail { get; set; }
		public string ContactName2 { get; set; }
		public string ContactEmail2 { get; set; }
		public int SalespersonId { get; set; }
		public int InventoryLimit { get; set; }
		public int Enabled { get; set; }
		public int UseVinDecode { get; set; }
		public int InternetId { get; set; }
		public int StickerCredits { get; set; }
		public int JMACredits { get; set; }
		public int AddendumCredits { get; set; }
		public string GMFields { get; set; }
		public string LogoFile { get; set; }
		public string GlobalNotes { get; set; }
		public string DealershipNotes { get; set; }
		public string BookValueNotes { get; set; }
		public string PriceNotes { get; set; }
		public string DiscountNotes { get; set; }
		public string FinalPriceNotes { get; set; }
		public string NoPriceNotes { get; set; }
		public string CarfaxUserId { get; set; }
		public string CarfaxPassword { get; set; }
		public int CarfaxAutoPurchase { get; set; }
		public string ExperianId { get; set; }
		public int PrintBarcode { get; set; }
		public bool PrintQRBarcode { get; set; }
		public int PrintLogo { get; set; }
		public int PrintVHLogo { get; set; }
		public int PrintBuyersGuide { get; set; }
		public int PrintPrice { get; set; }
		public int PrintAddPrice { get; set; }
		public int PrintPedigree { get; set; }
        [ObsoleteAttribute("This property is obsolete", false)]
        public int AllowCarfax { get; set; }      // THIS FIELD IS OBSOLETE
        [ObsoleteAttribute("This property is obsolete", false)]
        public int AllowExperian { get; set; }    // THIS FIELD IS OBSOLETE
		public int CopyPedigreeImage { get; set; }
		public int AutoUpload { get; set; }
		public int CopyPrice { get; set; }
		public string RDataSource { get; set; }
		public int HomepageContentId { get; set; }
        [ObsoleteAttribute("This property is obsolete", false)]
        public int NADAPrices { get; set; }
        [ObsoleteAttribute("This property is obsolete", false)]
        public string NADARegionDescription { get; set; }
        [ObsoleteAttribute("This property is obsolete", false)]
        public int NADARegionId { get; set; }
        [ObsoleteAttribute("This property is obsolete", false)]
        public int AutoCopyNada { get; set; }

        [ObsoleteAttribute("This property is obsolete", false)]
        public int DMSAutoSync { get; set; }
        [ObsoleteAttribute("This property is obsolete", false)]
        public int DMSAutoUpdate { get; set; }
        [ObsoleteAttribute("This property is obsolete", false)]
        public int NADAAutoSync { get; set; }
        [ObsoleteAttribute("This property is obsolete", false)]
        public int NADAAutoUpdate { get; set; } 

        public int AdCreator { get; set; }
		public string WebsiteUrl { get; set; }

		public int AssociationId { get; set; }
		public int GroupId { get; set; }

		public bool EnableDealerFrameParameterEditing { get; set; }
		public bool VendorImportEnrolled { get; set; }
		public bool VendorImportEnabled { get; set; }
		public string VendorImportVendorName { get; set; }
		public string VendorImportFileName { get; set; }
		public bool VendorImportFull { get; set; }
		public DateTime VendorImportLastImportReceived { get; set; }
	    public bool VendorImportEquipFiltering { get; set; }

	    public bool DisableDataExport { get; set; }

	    public bool AllowInventoryPurge { get; set; }
	    public int InventoryPurgeFrequency { get; set; }
	    public bool InventoryPurgeAuto { get; set; }

	    public bool EnableEnhancedData { get; set; }


}
}
