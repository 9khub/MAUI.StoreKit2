using System;
using Foundation;
using ObjCRuntime;

namespace StoreKit2
{
    /// <summary>
    /// PaymentManager is the main class for managing in-app purchases.
    /// It provides methods to request products, purchase products, restore purchases, and check purchase status.
    /// It also provides a delegate for handling purchase events.
    /// </summary>
    // @interface PaymentManager : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC18StoreKit2Framework14PaymentManager")]
    [DisableDefaultCtor]
    interface PaymentManager
    {
        /// <summary>
        /// The shared instance of the PaymentManager.
        /// </summary>
        // @property (readonly, nonatomic, strong, class) PaymentManager * _Nonnull shared;
        [Static]
        [Export("shared", ArgumentSemantic.Strong)]
        PaymentManager Shared { get; }

        /// <summary>
        /// The delegate for handling purchase events.
        /// </summary>
        [Wrap("WeakDelegate")]
        [NullAllowed]
        PaymentManagerDelegate Delegate { get; set; }

        /// <summary>
        /// The delegate for handling purchase events.
        /// </summary>
        // @property (nonatomic, weak) id<PaymentManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        /// <summary>
        /// Requests products from the App Store.
        /// </summary>
        /// <param name="productIds">The product IDs to request.</param>
        /// <param name="completion">The completion handler to call when the request is complete.</param>
        // -(void)requestProductsWithProductIds:(NSArray<NSString *> * _Nonnull)productIds completion:(void (^ _Nonnull)(BOOL, NSString * _Nullable))completion;
        [Export("requestProductsWithProductIds:completion:")]
        void RequestProductsWithProductIds(string[] productIds, Action<bool, NSString> completion);

        /// <summary>
        /// Purchases a product from the App Store.
        /// </summary>
        /// <param name="productId">The product ID to purchase.</param>
        /// <param name="appAccountToken">The app account token to use for the purchase.</param>
        /// <param name="completion">The completion handler to call when the purchase is complete.</param>
        // -(void)purchaseProductWithProductId:(NSString * _Nonnull)productId appAccountToken:(NSUUID * _Nullable)appAccountToken completion:(void (^ _Nonnull)(BOOL, NSString * _Nullable))completion;
        [Export("purchaseProductWithProductId:appAccountToken:completion:")]
        void PurchaseProductWithProductId(string productId, [NullAllowed] NSUuid appAccountToken, Action<bool, NSString> completion);

        /// <summary>
        /// Restores purchases from the App Store.
        /// </summary>
        /// <param name="completion">The completion handler to call when the restore is complete.</param>
        // -(void)restorePurchasesWithCompletion:(void (^ _Nonnull)(BOOL, NSString * _Nullable))completion;
        [Export("restorePurchasesWithCompletion:")]
        void RestorePurchasesWithCompletion(Action<bool, NSString> completion);

        /// <summary>
        /// Gets a product requested.
        /// </summary>
        /// <param name="productId">The product ID to get.</param>
        /// <returns>The product.</returns>
        // -(PaymentProduct * _Nullable)getProductWithProductId:(NSString * _Nonnull)productId __attribute__((warn_unused_result("")));
        [Export("getProductWithProductId:")]
        [return: NullAllowed]
        PaymentProduct GetProductWithProductId(string productId);

        /// <summary>
        /// Gets all products requested.
        /// </summary>
        /// <returns>The products.</returns>
        // -(NSArray<PaymentProduct *> * _Nonnull)getAllProducts __attribute__((warn_unused_result("")));
        [Export("getAllProducts")]
        PaymentProduct[] AllProducts { get; }

        /// <summary>
        /// Checks the purchase status of a product.
        /// </summary>
        /// <param name="productId">The product ID to check.</param>
        /// <param name="completion">The completion handler to call when the check is complete.</param>
        // -(void)checkPurchaseStatusWithProductId:(NSString * _Nonnull)productId completion:(void (^ _Nonnull)(BOOL, PaymentTransaction * _Nullable))completion;
        [Export("checkPurchaseStatusWithProductId:completion:")]
        void CheckPurchaseStatusWithProductId(string productId, Action<bool, PaymentTransaction> completion);
    }

    /// <summary>
    /// PaymentManagerDelegate is the delegate for handling purchase events.
    /// It provides methods to handle purchase events.
    /// </summary>
    // @protocol PaymentManagerDelegate
    [Protocol(Name = "_TtP18StoreKit2Framework22PaymentManagerDelegate_"), Model]
    [BaseType(typeof(NSObject))]
    interface PaymentManagerDelegate
    {
        /// <summary>
        /// Called when a purchase is finished.
        /// </summary>
        /// <param name="productId">The product ID of the purchased product.</param>
        /// <param name="transaction">The transaction of the purchased product.</param>
        // @optional -(void)paymentManagerDidFinishPurchase:(NSString * _Nonnull)productId transaction:(PaymentTransaction * _Nonnull)transaction;
        [Export("paymentManagerDidFinishPurchase:transaction:")]
        void PaymentManagerDidFinishPurchase(string productId, PaymentTransaction transaction);

        /// <summary>
        /// Called when a purchase fails.
        /// </summary>
        /// <param name="productId">The product ID of the failed product.</param>
        /// <param name="error">The error message.</param>
        // @optional -(void)paymentManagerDidFailPurchase:(NSString * _Nonnull)productId error:(NSString * _Nonnull)error;
        [Export("paymentManagerDidFailPurchase:error:")]
        void PaymentManagerDidFailPurchase(string productId, string error);

        /// <summary>
        /// Called when the products are updated.
        /// </summary>
        /// <param name="products">The products.</param>
        // @optional -(void)paymentManagerDidUpdateProducts:(NSArray<PaymentProduct *> * _Nonnull)products;
        [Export("paymentManagerDidUpdateProducts:")]
        void PaymentManagerDidUpdateProducts(PaymentProduct[] products);

        /// <summary>
        /// Called when the purchases are restored.
        /// </summary>
        /// <param name="transactions">The transactions.</param>
        // @optional -(void)paymentManagerDidRestorePurchases:(NSArray<PaymentTransaction *> * _Nonnull)transactions;
        [Export("paymentManagerDidRestorePurchases:")]
        void PaymentManagerDidRestorePurchases(PaymentTransaction[] transactions);
    }

    /// <summary>
    /// PaymentProduct is the class for representing a product.
    /// It provides information about the product.
    /// </summary>
    // @interface PaymentProduct : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC18StoreKit2Framework14PaymentProduct")]
    [DisableDefaultCtor]
    interface PaymentProduct
    {
        /// <summary>
        /// The product ID.
        /// </summary>
        // @property (readonly, copy, nonatomic) NSString * _Nonnull productId;
        [Export("productId")]
        string ProductId { get; }

        /// <summary>
        /// The display name of the product.
        /// </summary>
        // @property (readonly, copy, nonatomic) NSString * _Nonnull displayName;
        [Export("displayName")]
        string DisplayName { get; }

        /// <summary>
        /// The description of the product.
        /// </summary>
        // @property (readonly, copy, nonatomic) NSString * _Nonnull productDescription;
        [Export("productDescription")]
        string ProductDescription { get; }

        /// <summary>
        /// The price of the product.
        /// </summary>
        // @property (readonly, nonatomic, strong) NSDecimalNumber * _Nonnull price;
        [Export("price", ArgumentSemantic.Strong)]
        NSDecimalNumber Price { get; }

        /// <summary>
        /// The display price of the product.
        /// </summary>
        // @property (readonly, copy, nonatomic) NSString * _Nonnull displayPrice;
        [Export("displayPrice")]
        string DisplayPrice { get; }

        /// <summary>
        /// The type of the product.
        /// </summary>
        // @property (readonly, copy, nonatomic) NSString * _Nonnull productType;
        [Export("productType")]
        string ProductType { get; }
    }

    /// <summary>
    /// PaymentTransaction is the class for representing a transaction.
    /// It provides information about the transaction.
    /// </summary>
    // @interface PaymentTransaction : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC18StoreKit2Framework18PaymentTransaction")]
    [DisableDefaultCtor]
    interface PaymentTransaction
    {
        /// <summary>
        /// The transaction ID.
        /// </summary>
        // @property (readonly, copy, nonatomic) NSString * _Nonnull transactionId;
        [Export("transactionId")]
        string TransactionId { get; }

        /// <summary>
        /// The product ID.
        /// </summary>
        // @property (readonly, copy, nonatomic) NSString * _Nonnull productId;
        [Export("productId")]
        string ProductId { get; }

        /// <summary>
        /// The purchase date.
        /// </summary>
        // @property (readonly, copy, nonatomic) NSDate * _Nonnull purchaseDate;
        [Export("purchaseDate", ArgumentSemantic.Copy)]
        NSDate PurchaseDate { get; }

        /// <summary>
        /// Whether the transaction is upgraded.
        /// </summary>
        // @property (readonly, nonatomic) BOOL isUpgraded;
        [Export("isUpgraded")]
        bool IsUpgraded { get; }

        /// <summary>
        /// The revocation date.
        /// </summary>
        // @property (readonly, copy, nonatomic) NSDate * _Nullable revocationDate;
        [NullAllowed, Export("revocationDate", ArgumentSemantic.Copy)]
        NSDate RevocationDate { get; }

        /// <summary>
        /// The revocation reason.
        /// </summary>
        // @property (readonly, copy, nonatomic) NSString * _Nullable revocationReason;
        [NullAllowed, Export("revocationReason")]
        string RevocationReason { get; }
    }
}
