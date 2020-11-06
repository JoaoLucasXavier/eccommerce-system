# Add migration
- Migration path: eccommerce-system\src
- CLI: dotnet ef migrations add Initial -s Web -p Infra --context ECommerceContext -v
- CLI: dotnet ef database update -s Web -p Infra --context ECommerceContext -v


# Update migration
- Migration path: eccommerce-system\src
- CLI: dotnet ef migrations add UpdateDatabase -s Web -p Infra --context ECommerceContext -v
- CLI: dotnet ef database update -s Web -p Infra --context ECommerceContext -v
