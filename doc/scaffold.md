# Product

- dotnet aspnet-codegenerator controller -name ProductsController --relativeFolderPath Controllers --readWriteActions

- dotnet aspnet-codegenerator razorpage Index List -m Entities.Product -dc ECommerceContext -outDir Views/Products --useDefaultLayout
- dotnet aspnet-codegenerator razorpage Details Details -m Entities.Product -dc ECommerceContext -outDir Views/Products --useDefaultLayout
- dotnet aspnet-codegenerator razorpage Create Create -m Entities.Product -dc ECommerceContext -outDir Views/Products --useDefaultLayout
- dotnet aspnet-codegenerator razorpage Edit Edit -m Entities.Product -dc ECommerceContext -outDir Views/Products --useDefaultLayout
- dotnet aspnet-codegenerator razorpage Delete Delete -m Entities.Product -dc ECommerceContext -outDir Views/Products --useDefaultLayout


# Identity

- dotnet aspnet-codegenerator identity -h
- dotnet aspnet-codegenerator identity -dc ECommerceContext


# Purchase User

- dotnet aspnet-codegenerator controller -name UserPurchasesController --relativeFolderPath Controllers


