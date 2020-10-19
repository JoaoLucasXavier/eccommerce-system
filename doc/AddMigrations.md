- Migration path: eccommerce-system\src

- CLI: dotnet ef migrations add Initial -s Presentation -p Infra --context ECommerceContext -v
- CLI: dotnet ef database update -s Presentation -p Infra --context ECommerceContext -v
