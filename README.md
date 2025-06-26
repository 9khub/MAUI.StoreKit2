![NuGet Version](https://img.shields.io/nuget/v/StoreKit2?link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FStoreKit2)

# MAUI StoreKit2 IAP Module

A .NET MAUI binding library that provides seamless integration with iOS StoreKit2 In-App Purchase functionality.

## Overview

This library enables .NET MAUI applications to leverage Apple's modern StoreKit2 framework for handling in-app purchases on iOS. It provides a C# wrapper around the native StoreKit2 APIs, making it easy to integrate IAP functionality into your cross-platform MAUI applications.

## Features

- ✅ **Product Information Retrieval**: Fetch product details from the App Store
- ✅ **Purchase Processing**: Handle consumable, non-consumable, and subscription purchases
- ✅ **Purchase Restoration**: Restore previous purchases for users
- ✅ **Transaction Verification**: Built-in transaction verification using StoreKit2
- ✅ **Purchase Status Checking**: Check the current entitlement status of products
- ✅ **Async/Await Support**: Modern async programming patterns
- ✅ **Delegate Pattern**: Event-driven callbacks for purchase events
- ✅ **iOS 15+ Support**: Takes advantage of the latest StoreKit2 features

## Requirements

- **iOS 15.0+** (StoreKit2 requirement)
- **.NET 8.0** or later
- **MAUI Project** targeting iOS

## Prerequisites

### App Store Connect Setup
1. Create your app in App Store Connect
2. Configure In-App Purchase products with the same product IDs used in your code
3. Create sandbox test users for testing

### iOS Project Requirements  
1. iOS 15.0+ deployment target
2. Valid Bundle ID matching App Store Connect
3. StoreKit capability enabled in your iOS project

## Installation

### NuGet Package

```bash
dotnet add package StoreKit2
```

Or add to your `.csproj` file:

```xml
<PackageReference Include="StoreKit2" Version="1.0.0" />
```

### Manual Installation

1. Clone this repository
2. Add the project reference to your MAUI project:
   ```xml
   <ProjectReference Include="path/to/MAUI.StoreKit2/MAUI.StoreKit2.csproj" />
   ```
3. Build and run

## Quick Start

### 1. Initialize the Payment Manager

```csharp
using StoreKit2;

// Get the shared instance
var paymentManager = PaymentManager.Shared;

// Set up delegate for callbacks
paymentManager.Delegate = new PaymentManagerDelegateImpl();
```

### 2. Create a Delegate Implementation

```csharp
public class PaymentManagerDelegateImpl : PaymentManagerDelegate
{
    public override void PaymentManagerDidFinishPurchase(string productId, PaymentTransaction transaction)
    {
        Console.WriteLine($"Purchase completed: {productId}");
        // Handle successful purchase
    }

    public override void PaymentManagerDidFailPurchase(string productId, string error)
    {
        Console.WriteLine($"Purchase failed: {productId}, Error: {error}");
        // Handle purchase failure
    }

    public override void PaymentManagerDidUpdateProducts(PaymentProduct[] products)
    {
        Console.WriteLine($"Products loaded: {products.Length}");
        // Update UI with product information
    }

    public override void PaymentManagerDidRestorePurchases(PaymentTransaction[] transactions)
    {
        Console.WriteLine($"Restored {transactions.Length} purchases");
        // Handle restored purchases
    }
}
```

### 3. Load Products

```csharp
string[] productIds = { "com.yourapp.product1", "com.yourapp.product2" };

paymentManager.RequestProductsWithProductIds(productIds, (success, error) =>
{
    if (success)
    {
        Console.WriteLine("Products loaded successfully");
        var products = paymentManager.GetAllProducts;
        // Display products in your UI
    }
    else
    {
        Console.WriteLine($"Failed to load products: {error}");
    }
});
```

### 4. Make a Purchase

```csharp
paymentManager.PurchaseProductWithProductId("com.yourapp.product1", null, (success, error) =>
{
    if (success)
    {
        Console.WriteLine("Purchase initiated successfully");
    }
    else
    {
        Console.WriteLine($"Purchase failed: {error}");
    }
});
```

### 5. Restore Purchases

```csharp
paymentManager.RestorePurchasesWithCompletion((success, error) =>
{
    if (success)
    {
        Console.WriteLine("Purchases restored successfully");
    }
    else
    {
        Console.WriteLine($"Restore failed: {error}");
    }
});
```

### 6. Check Purchase Status

```csharp
paymentManager.CheckPurchaseStatusWithProductId("com.yourapp.product1", (hasPurchase, transaction) =>
{
    if (hasPurchase)
    {
        Console.WriteLine($"User owns this product. Transaction ID: {transaction.TransactionId}");
    }
    else
    {
        Console.WriteLine("User does not own this product");
    }
});
```

## API Reference

### PaymentManager

The main class for handling in-app purchases.

#### Properties

- `Shared`: Static singleton instance
- `Delegate`: Delegate for receiving purchase events

#### Methods

- `RequestProductsWithProductIds()`: Load product information from the App Store
- `PurchaseProductWithProductId()`: Initiate a purchase for a specific product
- `RestorePurchasesWithCompletion()`: Restore previous purchases
- `GetProductWithProductId()`: Get product information by ID
- `AllProducts`: Get all loaded products
- `CheckPurchaseStatusWithProductId()`: Check if user owns a specific product

### PaymentProduct

Represents a product available for purchase.

#### Properties

- `ProductId`: Unique product identifier
- `DisplayName`: Localized product name
- `ProductDescription`: Localized product description
- `Price`: Product price as NSDecimalNumber
- `DisplayPrice`: Formatted price string
- `ProductType`: Product type (consumable, nonConsumable, etc.)

### PaymentTransaction

Represents a completed transaction.

#### Properties

- `TransactionId`: Unique transaction identifier
- `ProductId`: Associated product identifier
- `PurchaseDate`: Date of purchase
- `IsUpgraded`: Whether this is an upgrade transaction
- `RevocationDate`: Date of revocation (if applicable)
- `RevocationReason`: Reason for revocation (if applicable)

## Product Types

The library supports all StoreKit2 product types:

- **Consumable**: Products that can be purchased multiple times
- **Non-Consumable**: Products that are purchased once
- **Auto-Renewable**: Subscriptions that renew automatically
- **Non-Renewable**: Subscriptions that don't renew automatically

## Error Handling

The library provides comprehensive error handling through:

- Completion callbacks with success/error parameters
- Delegate methods for handling purchase failures
- Detailed error messages for debugging

## Testing

For testing in-app purchases:

1. Use Apple's sandbox environment
2. Create test user accounts in App Store Connect
3. Configure your products in App Store Connect
4. Test on physical devices (StoreKit2 doesn't work in simulator)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Support

If you encounter any issues or have questions:

1. Check the [Issues](https://github.com/9khub/MAUI.StoreKit2/issues) page
2. Create a new issue with detailed information
3. Provide sample code and error messages when applicable

## Author

**Yuting Li**  
Shanghai Jiuqianji Technology Co., Ltd.

## Acknowledgments

- Apple's StoreKit2 documentation and samples
- The .NET MAUI community for guidance and support
