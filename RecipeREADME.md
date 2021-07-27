# DDD Magenic Masters Class

Domain Driven Design

## Project Description

The project chosen for this class was to build a recipe inventory system for a restaurant. The objective was to design a inventory tracking system such that as orders are made then inventory items will be deducted based on the the recipe ingredients. When an inventory item "quantity" is reduced to a certain threshold from numerous orders then an inventory order is generated. Once the inventory order is delivered then the quantity value is updated for that inventory item. 

The primary entity that controls the inventory deduction is the Ingredient Item (Prelim) where you identity the amount consumed in the recipe amd the amount consumed in the inventory item. Am ingredient in a recipe may define consumption based on things like tsps, tbsps, cups, etc while the inventory item would track things in ibs, gallons, quarts, or event indiviual items like a single onion. You can see some examples of this in the FoodItem screenshots.

## Design Limitations

I chose not to include anything related to the cost of inventory and how that gets reflected in the order cost. Although it is closely tied to inventory it has nothing to do with tracking inventory consumption.

## Objectives

In addition to creating a design model I wanted to go further and evaluate how my design would affect development activities. So I chose to build 3 projects: (1) Class library, (2) web front end and (3) backend REST API. 

* /Projects/RecipeClassLibrary
* /Projects/RecipeBlazor1
* /Projects/RecipeAPI1

## Project Status

I initially started building the front end with Razor. Eventually I switched to a Blazor front end at a late date. I wish I had done that earlier as I would have been able to completed the implementation of the inventory adustment interface which is where inventory adjustment can be made in numerous ways: orders, deliveries, manual stock adjustment, etc... In any case I was able to setup inventory items, a menu iterface where the user can create recipes, assign food item consumption and attach to a menu system. I decided to ignore building an Order interface and instead define a simulator that would randomly generate orders. The final objective was to adjust inventory accordingly based on orders created and generate inventory orders as needed. Therefore the project remains a work in progress. 

## Suggestions

I would like to see a Masters level class in the implementation of SOLID principles with development projects, API's and web front ends. I struggled a lot with implementing an EF code first approach for defining the database and how that gets reflected in CRUD operations in the API's. At one point I had to clean out several entities and controllers and restart my EF migrations. From that experience it seems impractical to try and manage a large database using the code first approach through all development cycles. 
