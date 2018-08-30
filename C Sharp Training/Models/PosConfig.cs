using System;
using System.Collections.Generic;

namespace C_Sharp_Training.Models
{
    public partial class PosConfig
    {
        public int Id { get; set; }
        public int? PosId { get; set; }
        public string PosName { get; set; }
        public int? PosLocalProductId { get; set; }
        public int? PosPromotionId { get; set; }
        public string JournalIdsString { get; set; }
        public string PosPaymentsActiveString { get; set; }
        public string LastSyncTimeSupplier { get; set; }
        public string LastSyncTimeProduct { get; set; }
        public string LastSyncTimeAnnouncement { get; set; }
        public string LastSyncTimePromotion { get; set; }
        public string CompanyName { get; set; }
        public string CompanyInfo { get; set; }
        public float? TaxValue { get; set; }
        public bool? TaxEnable { get; set; }
        public bool? ProductChineseNameEnable { get; set; }
        public bool? CashdrawerPinEnable { get; set; }
        public bool? StandAlone { get; set; }
        public bool? ReceiptLogoEnable { get; set; }
        public string ReceiptFooter { get; set; }
        public bool? AllowPriceLowerThanCostPrice { get; set; }
        public bool? ManagerVoidOnlyEnable { get; set; }
        public bool? DailySessionEnable { get; set; }
        public bool? AddTaxToMiscProductEnable { get; set; }
        public bool? SecureLoginEnable { get; set; }
        public bool? SecureLoginAlphanumericEnable { get; set; }
        public int? SecureLoginMinPasswordLength { get; set; }
        public int? SecureLoginMaxPasswordAge { get; set; }
        public int? SecureLoginMinPasswordAge { get; set; }
        public int? SecureLoginMaxInvalidLoginAttempt { get; set; }
        public int? SecureLoginNoDifferentFromPreviousPassword { get; set; }
        public bool? RoundingCashPaymentEnable { get; set; }
        public float? RoundingToNearestValue { get; set; }
        public bool? ShouldRoundUp { get; set; }
        public int? RolePowerLevelToChangePayment { get; set; }
        public int? RolePowerLevelToViewReport { get; set; }
        public int? RolePowerLevelToRefund { get; set; }
        public int? RolePowerLevelToDiscount { get; set; }
    }
}
