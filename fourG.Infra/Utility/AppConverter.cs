using fourG.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace fourG.Infra.Utility
{
    public class AppConverter
    {
        public static LteOrder ToLteOrder(DataRow row)
        {
            var order = new LteOrder();
            order.Id = row["row_no"] == DBNull.Value ? 0 : Convert.ToInt32(row["row_no"]);
            order.MobileNo = row["mobile_no"] == DBNull.Value ? string.Empty : Convert.ToString(row["mobile_no"]);
            order.IsExist = row["isexist"] == DBNull.Value ? false : Convert.ToBoolean(row["isexist"]);
            order.OrderType = row["order_type"] == DBNull.Value ? 0 : Convert.ToInt32(row["order_type"]);
            order.ExpiredOn = row["exp_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["exp_date"]);
            order.Postpaid = row["postpaid"] == DBNull.Value ? 0 : Convert.ToInt32(row["postpaid"]);
            order.IMSI = row["imsi"] == DBNull.Value ? string.Empty : Convert.ToString(row["imsi"]);
            order.IMSIPassword = row["imsi_pass"] == DBNull.Value ? string.Empty : Convert.ToString(row["imsi_pass"]);
            order.PackageId = row["pkg_id"] == DBNull.Value ? string.Empty : Convert.ToString(row["pkg_id"]);
            order.AlterPackageId = row["alter_pkg_id"] == DBNull.Value ? string.Empty : Convert.ToString(row["alter_pkg_id"]);
            order.PackageValidity = row["bkg_validity"] == DBNull.Value ? 0 : Convert.ToInt32(row["bkg_validity"]);
            order.OfferId = row["offer_id"] == DBNull.Value ? string.Empty : Convert.ToString(row["offer_id"]);
            order.Status = row["STATUS"] == DBNull.Value ? 0 : Convert.ToInt32(row["STATUS"]);
            order.AAAStatus = row["AAA_status"] == DBNull.Value ? 0 : Convert.ToInt32(row["AAA_status"]);
            order.PRLStatus = row["prl_status"] == DBNull.Value ? 0 : Convert.ToInt32(row["prl_status"]);
            order.CRMStatus = row["crm_status"] == DBNull.Value ? 0 : Convert.ToInt32(row["crm_status"]);
            order.HSSStatus = row["hss_status"] == DBNull.Value ? 0 : Convert.ToInt32(row["hss_status"]);
            order.Channel = row["channel"] == DBNull.Value ? string.Empty : Convert.ToString(row["channel"]);
            order.CreatedOn = row["enter_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["enter_date"]);
            order.ClosedOn = row["close_time"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["close_time"]);
            order.Note = row["note"] == DBNull.Value ? string.Empty : Convert.ToString(row["note"]);
            return order;
        }
        public static LteOrderHistory ToLteOrderHistory(DataRow row)
        {
            var order = new LteOrderHistory();
            order.Id = row["row_no"] == DBNull.Value ? 0 : Convert.ToInt32(row["row_no"]);
            order.MobileNo = row["mobile_no"] == DBNull.Value ? string.Empty : Convert.ToString(row["mobile_no"]);
            order.IsExist = row["isexist"] == DBNull.Value ? false : Convert.ToBoolean(row["isexist"]);
            order.OrderType = row["order_type"] == DBNull.Value ? 0 : Convert.ToInt32(row["order_type"]);
            order.ExpiredOn = row["exp_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["exp_date"]);
            order.Postpaid = row["postpaid"] == DBNull.Value ? 0 : Convert.ToInt32(row["postpaid"]);
            order.IMSI = row["imsi"] == DBNull.Value ? string.Empty : Convert.ToString(row["imsi"]);
            order.IMSIPassword = row["imsi_pass"] == DBNull.Value ? string.Empty : Convert.ToString(row["imsi_pass"]);
            order.PackageId = row["pkg_id"] == DBNull.Value ? string.Empty : Convert.ToString(row["pkg_id"]);
            order.AlterPackageId = row["alter_pkg_id"] == DBNull.Value ? string.Empty : Convert.ToString(row["alter_pkg_id"]);
            order.PackageValidity = row["bkg_validity"] == DBNull.Value ? 0 : Convert.ToInt32(row["bkg_validity"]);
            order.OfferId = row["offer_id"] == DBNull.Value ? string.Empty : Convert.ToString(row["offer_id"]);
            order.Status = row["STATUS"] == DBNull.Value ? 0 : Convert.ToInt32(row["STATUS"]);
            order.AAAStatus = row["AAA_status"] == DBNull.Value ? 0 : Convert.ToInt32(row["AAA_status"]);
            order.PRLStatus = row["prl_status"] == DBNull.Value ? 0 : Convert.ToInt32(row["prl_status"]);
            order.CRMStatus = row["crm_status"] == DBNull.Value ? 0 : Convert.ToInt32(row["crm_status"]);
            order.HSSStatus = row["hss_status"] == DBNull.Value ? 0 : Convert.ToInt32(row["hss_status"]);
            order.Channel = row["channel"] == DBNull.Value ? string.Empty : Convert.ToString(row["channel"]);
            order.CreatedOn = row["enter_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["enter_date"]);
            order.ClosedOn = row["close_time"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["close_time"]);
            order.Note = row["note"] == DBNull.Value ? string.Empty : Convert.ToString(row["note"]);
            return order;
        }
        public static MobileOffer ToMobileOffer(DataRow row)
        {
            var order = new MobileOffer();
            order.Id = row["row_no"] == DBNull.Value ? 0 : Convert.ToInt32(row["row_no"]);
            order.MobileNo = row["mobile_no"] == DBNull.Value ? string.Empty : Convert.ToString(row["mobile_no"]);
            order.OfferId = row["offer_id"] == DBNull.Value ? string.Empty : Convert.ToString(row["offer_id"]);
            order.LastOperation = row["last_op"] == DBNull.Value ? 0 : Convert.ToInt32(row["last_op"]);
            order.OfferName = row["offer_name"] == DBNull.Value ? string.Empty : Convert.ToString(row["offer_name"]);
            order.CreatedOn = row["enter_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["enter_date"]);
            order.SubscribedOn = row["last_sub_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["last_sub_date"]);
            return order;
        }

        public static OperationLog ToOperationLog(DataRow row)
        {
            var result = new OperationLog();
            result.Id = row["row_no"] == DBNull.Value ? 0 : Convert.ToInt32(row["row_no"]);
            result.MobileNo = row["mobile_no"] == DBNull.Value ? string.Empty : Convert.ToString(row["mobile_no"]);
            result.Result = row["result_msg"] == DBNull.Value ? string.Empty : Convert.ToString(row["result_msg"]);
            result.TransactionId = row["trans_no"] == DBNull.Value ? 0 : Convert.ToInt32(row["trans_no"]);
            result.OperationCode = row["op_code"] == DBNull.Value ? string.Empty : Convert.ToString(row["op_code"]);
            result.CreatedOn = row["enter_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["enter_date"]);
            return result;
        }
        public static Product ToProduct(DataRow row)
        {
            var result = new Product();
            result.Id = row["product_no"] == DBNull.Value ? 0 : Convert.ToInt32(row["product_no"]);
            result.FirstId = row["product_id1"] == DBNull.Value ? string.Empty : Convert.ToString(row["product_id1"]);
            result.SecondId = row["product_id2"] == DBNull.Value ? string.Empty : Convert.ToString(row["product_id2"]);
            result.Name = row["product_name"] == DBNull.Value ? string.Empty : Convert.ToString(row["product_name"]);
            result.Fee = row["product_fee"] == DBNull.Value ? 0 : Convert.ToDouble(row["product_fee"]);
            result.Size = row["product_size"] == DBNull.Value ? 0 : Convert.ToDouble(row["product_size"]);
            result.Validity = row["product_validity"] == DBNull.Value ? 0 : Convert.ToInt32(row["product_validity"]);
            result.PrepaidOfferId = row["pre_offer_id"] == DBNull.Value ? string.Empty : Convert.ToString(row["pre_offer_id"]);
            result.PostpaidOfferId = row["post_offer_id"] == DBNull.Value ? string.Empty : Convert.ToString(row["post_offer_id"]);
            return result;
        }

        public static SubscriberExceedMaxValidity ToSubscriberExceedMaxValidity(DataRow row)
        {
            var result = new SubscriberExceedMaxValidity();
            result.Id = row["row_no"] == DBNull.Value ? 0 : Convert.ToInt32(row["row_no"]);
            result.MobileNo = row["mobile_no"] == DBNull.Value ? string.Empty : Convert.ToString(row["mobile_no"]);
            result.PackageId = row["pkg_id"] == DBNull.Value ? string.Empty : Convert.ToString(row["pkg_id"]);
            result.PackageName = "Unknown";
            result.OperationType = row["op_type"] == DBNull.Value ? 0 : Convert.ToInt32(row["op_type"]);
            result.CreatedOn = row["enter_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["enter_date"]);
            return result;
        }
        public static Subscriber ToSubscriber(DataRow row)
        {
            var result = new Subscriber();
            result.Id = row["row_no"] == DBNull.Value ? 0 : Convert.ToInt32(row["row_no"]);
            result.MobileNo = row["mobile_no"] == DBNull.Value ? string.Empty : Convert.ToString(row["mobile_no"]);
            result.IMSI = row["imsi"] == DBNull.Value ? string.Empty : Convert.ToString(row["imsi"]);
            result.RegisteredOn = row["reg_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["reg_date"]);
            result.ExpiredOn = row["exp_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["exp_date"]);
            result.Status = row["status"] == DBNull.Value ? 0 : Convert.ToInt32(row["status"]);
            result.LastPackageOn = row["last_bkg_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["last_bkg_date"]);
            result.LastPackageId = row["last_bkg_id"] == DBNull.Value ? string.Empty : Convert.ToString(row["last_bkg_id"]);
            result.LastPackageName = "Unknown";
            result.AAAStatus = row["aaa_status"] == DBNull.Value ? 0 : Convert.ToInt32(row["aaa_status"]);
            result.HSSStatus = row["hss_status"] == DBNull.Value ? 0 : Convert.ToInt32(row["hss_status"]);
            return result;
        }
        public static SubscriberPackage ToSubscriberPackage(DataRow row)
        {
            var result = new SubscriberPackage();
            result.Id = row["row_no"] == DBNull.Value ? 0 : Convert.ToInt32(row["row_no"]);
            result.MobileNo = row["mobile_no"] == DBNull.Value ? string.Empty : Convert.ToString(row["mobile_no"]);
            result.PackageId = row["bkg_id"] == DBNull.Value ? string.Empty : Convert.ToString(row["bkg_id"]);
            result.PackageName = "N/A";
            result.StartedOn = row["eff_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["eff_date"]);
            result.ExpiredOn = row["exp_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["exp_date"]);
            result.Status = row["status"] == DBNull.Value ? 0 : Convert.ToInt32(row["status"]);
            return result;
        }
        public static SubscriberPackageHistory ToSubscriberPackageHistory(DataRow row)
        {
            var result = new SubscriberPackageHistory();
            result.Id = row["row_no"] == DBNull.Value ? 0 : Convert.ToInt32(row["row_no"]);
            result.MobileNo = row["mobile_no"] == DBNull.Value ? string.Empty : Convert.ToString(row["mobile_no"]);
            result.PackageId = row["bkg_id"] == DBNull.Value ? string.Empty : Convert.ToString(row["bkg_id"]);
            result.PackageName = "N/A";
            result.StartedOn = row["eff_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["eff_date"]);
            result.ExpiredOn = row["exp_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["exp_date"]);
            result.DeactivatedOn = row["deactivate_date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["deactivate_date"]);
            result.Status = row["status"] == DBNull.Value ? 0 : Convert.ToInt32(row["status"]);
            return result;
        }
        public static SMSReceiver ToSMSReceiver(DataRow row)
        {
            var result = new SMSReceiver();
            result.Id = row["row_no"] == DBNull.Value ? 0 : Convert.ToInt32(row["row_no"]);
            result.MobileNo = row["mobile_no"] == DBNull.Value ? string.Empty : Convert.ToString(row["mobile_no"]);
            result.Message = row["message"] == DBNull.Value ? string.Empty : Convert.ToString(row["message"]);
            result.Shortcode = row["shortcode"] == DBNull.Value ? string.Empty : Convert.ToString(row["shortcode"]);
            result.CreatedOn = row["createdOn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["createdOn"]);
            return result;
        }

        public static MessageSpool ToMessageSpool(DataRow row)
        {
            var result = new MessageSpool();
            result.Id = row["row_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["row_id"]);
            result.MobileNo = row["mobile_no"] == DBNull.Value ? string.Empty : Convert.ToString(row["mobile_no"]);
            result.Message = row["message"] == DBNull.Value ? string.Empty : Convert.ToString(row["message"]);
            result.Shortcode = row["shortcode"] == DBNull.Value ? string.Empty : Convert.ToString(row["shortcode"]);
            result.CreatedOn = row["createdOn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["createdOn"]);
            result.Status = row["status"] == DBNull.Value ? 0 : Convert.ToInt32(row["status"]);
            return result;
        }

        public static MessageSpoolHistory ToMessageSpoolHistory(DataRow row)
        {
            var result = new MessageSpoolHistory();
            result.Id = row["row_no"] == DBNull.Value ? 0 : Convert.ToInt32(row["row_no"]);
            result.MobileNo = row["mobile_no"] == DBNull.Value ? string.Empty : Convert.ToString(row["mobile_no"]);
            result.Message = row["message"] == DBNull.Value ? string.Empty : Convert.ToString(row["message"]);
            result.Shortcode = row["shortcode"] == DBNull.Value ? string.Empty : Convert.ToString(row["shortcode"]);
            result.CreatedOn = row["createdOn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["createdOn"]);
            result.BackedupOn = row["backedOn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["backedOn"]);
            result.Status = row["status"] == DBNull.Value ? 0 : Convert.ToInt32(row["status"]);
            return result;
        }

        public static AppRole ToAppRole(DataRow row)
        {
            var result = new AppRole();
            result.Id = row["role_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["role_id"]);
            result.Name = row["role_name"] == DBNull.Value ? string.Empty : Convert.ToString(row["role_name"]);
            result.CreatedOn = row["createdOn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["createdOn"]);
            result.Status = row["status"] == DBNull.Value ? 0 : Convert.ToInt32(row["status"]);
            return result;
        }

        public static AppOperator ToAppOperator(DataRow row)
        {
            var result = new AppOperator();
            result.Id = row["role_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["role_id"]);
            result.Name = row["role_name"] == DBNull.Value ? string.Empty : Convert.ToString(row["role_name"]);
            result.Secret = row["op_pass"] == DBNull.Value ? string.Empty : Convert.ToString(row["op_pass"]);
            result.SecretKey = row["op_extra"] == DBNull.Value ? string.Empty : Convert.ToString(row["op_extra"]);
            result.Status = row["status"] == DBNull.Value ? 0 : Convert.ToInt32(row["status"]);
            result.Attempts = row["attempts"] == DBNull.Value ? 0 : Convert.ToInt32(row["attempts"]);
            result.CreatedOn = row["createdOn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["createdOn"]);
            result.StatusChangedOn = row["statusChangedOn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["statusChangedOn"]);
            result.LastLoggedOn = row["lastLoggedOn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["lastLoggedOn"]);
            result.LockedTo = row["lockedOn"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["lockedOn"]);
            return result;
        }
    }
}
