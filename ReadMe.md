
# Scope
This is a proof of concept for a shopping basket with special offers:
 - The application has a store of items and special offers involving these items
 - The application is able to accept a list of items (a basket) and
    - correctly identify the items from their name
    - corretly price the items
    - correctly apply special offers
    - product a 'receipt' detailing the items, offers and basket total

# Constraints
 - The store of items and offers is hard coded (in Basket.cs) but in a way that should make it easy to replace with data from a data store.
 - No UI has been produced - the functionaity can be verified using the command line.

# Instructions For Use:
1. Build the solution
2. Open a command prompt
3. Navigate to the location of 'shopping.exe' (e.g. {solution directory}\Shopping\bin\Debug\netcoreapp3.1)
4. run the app from the command line with a list of items as parameters. Here are some examples that can be pasted into the command line:
    - shopping "bread" "butter" "milk"
    - shopping "bread" "butter" "bread" "butter"
    - shopping "milk" "milk" "milk" "milk"
    - shopping "milk" "milk" "milk" "milk" "butter" "butter" "bread" "milk" "milk" "milk" "milk"

Alternatively, the tests can be used to prove the functionality - in the *Shopping.Tests.Unit* project there are a series of data driven tests in the *BasketTests.cs* file.