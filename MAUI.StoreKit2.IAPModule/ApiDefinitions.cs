using System;
using Foundation;
using ObjCRuntime;

namespace MAUI.StoreKit2.IAPModule
{
    // @interface PaymentManager : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC18StoreKit2Framework14PaymentManager")]
    [DisableDefaultCtor]
    interface PaymentManager
    {
        // @property (readonly, nonatomic, strong, class) PaymentManager * _Nonnull shared;
        [Static]
        [Export("shared", ArgumentSemantic.Strong)]
        PaymentManager Shared { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        PaymentManagerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<PaymentManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(void)requestProductsWithProductIds:(NSArray<NSString *> * _Nonnull)productIds completion:(void (^ _Nonnull)(BOOL, NSString * _Nullable))completion;
        [Export("requestProductsWithProductIds:completion:")]
        void RequestProductsWithProductIds(string[] productIds, Action<bool, NSString> completion);

        // -(void)purchaseProductWithProductId:(NSString * _Nonnull)productId appAccountToken:(NSUUID * _Nullable)appAccountToken completion:(void (^ _Nonnull)(BOOL, NSString * _Nullable))completion;
        [Export("purchaseProductWithProductId:appAccountToken:completion:")]
        void PurchaseProductWithProductId(string productId, [NullAllowed] NSUuid appAccountToken, Action<bool, NSString> completion);

        // -(void)restorePurchasesWithCompletion:(void (^ _Nonnull)(BOOL, NSString * _Nullable))completion;
        [Export("restorePurchasesWithCompletion:")]
        void RestorePurchasesWithCompletion(Action<bool, NSString> completion);

        // -(PaymentProduct * _Nullable)getProductWithProductId:(NSString * _Nonnull)productId __attribute__((warn_unused_result("")));
        [Export("getProductWithProductId:")]
        [return: NullAllowed]
        PaymentProduct GetProductWithProductId(string productId);

        // -(NSArray<PaymentProduct *> * _Nonnull)getAllProducts __attribute__((warn_unused_result("")));
        [Export("getAllProducts")]
        PaymentProduct[] GetAllProducts { get; }

        // -(void)checkPurchaseStatusWithProductId:(NSString * _Nonnull)productId completion:(void (^ _Nonnull)(BOOL, PaymentTransaction * _Nullable))completion;
        [Export("checkPurchaseStatusWithProductId:completion:")]
        void CheckPurchaseStatusWithProductId(string productId, Action<bool, PaymentTransaction> completion);
    }

    // @protocol PaymentManagerDelegate
    [Protocol(Name = "_TtP18StoreKit2Framework22PaymentManagerDelegate_"), Model]
    [BaseType(typeof(NSObject))]
    interface PaymentManagerDelegate
    {
        // @optional -(void)paymentManagerDidFinishPurchase:(NSString * _Nonnull)productId transaction:(PaymentTransaction * _Nonnull)transaction;
        [Export("paymentManagerDidFinishPurchase:transaction:")]
        void PaymentManagerDidFinishPurchase(string productId, PaymentTransaction transaction);

        // @optional -(void)paymentManagerDidFailPurchase:(NSString * _Nonnull)productId error:(NSString * _Nonnull)error;
        [Export("paymentManagerDidFailPurchase:error:")]
        void PaymentManagerDidFailPurchase(string productId, string error);

        // @optional -(void)paymentManagerDidUpdateProducts:(NSArray<PaymentProduct *> * _Nonnull)products;
        [Export("paymentManagerDidUpdateProducts:")]
        void PaymentManagerDidUpdateProducts(PaymentProduct[] products);

        // @optional -(void)paymentManagerDidRestorePurchases:(NSArray<PaymentTransaction *> * _Nonnull)transactions;
        [Export("paymentManagerDidRestorePurchases:")]
        void PaymentManagerDidRestorePurchases(PaymentTransaction[] transactions);
    }

    // @interface PaymentProduct : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC18StoreKit2Framework14PaymentProduct")]
    [DisableDefaultCtor]
    interface PaymentProduct
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull productId;
        [Export("productId")]
        string ProductId { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull displayName;
        [Export("displayName")]
        string DisplayName { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull productDescription;
        [Export("productDescription")]
        string ProductDescription { get; }

        // @property (readonly, nonatomic, strong) NSDecimalNumber * _Nonnull price;
        [Export("price", ArgumentSemantic.Strong)]
        NSDecimalNumber Price { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull displayPrice;
        [Export("displayPrice")]
        string DisplayPrice { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull productType;
        [Export("productType")]
        string ProductType { get; }
    }

    // @interface PaymentTransaction : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC18StoreKit2Framework18PaymentTransaction")]
    [DisableDefaultCtor]
    interface PaymentTransaction
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull transactionId;
        [Export("transactionId")]
        string TransactionId { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull productId;
        [Export("productId")]
        string ProductId { get; }

        // @property (readonly, copy, nonatomic) NSDate * _Nonnull purchaseDate;
        [Export("purchaseDate", ArgumentSemantic.Copy)]
        NSDate PurchaseDate { get; }

        // @property (readonly, nonatomic) BOOL isUpgraded;
        [Export("isUpgraded")]
        bool IsUpgraded { get; }

        // @property (readonly, copy, nonatomic) NSDate * _Nullable revocationDate;
        [NullAllowed, Export("revocationDate", ArgumentSemantic.Copy)]
        NSDate RevocationDate { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable revocationReason;
        [NullAllowed, Export("revocationReason")]
        string RevocationReason { get; }
    }
}
