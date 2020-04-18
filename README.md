#Local Data Company Test
#SQL Test
#---------------------------------------------------------------
Given the following tables, write a query which returns the total 
footfall count per premises. The resultset should contain the 
following non-null columns: Business, StreetNo, Street, PostCode, 
FootfallCount. Premises do not necessarily have footfall for 
every week (missing counts will have a count of zero). 
Missing street numbers will be replaced with empty string ''.  
Query performance must not be affected by transactions 
which are running at the same time.


#C# Test
Write C# code with unit-tests to process a collection of string values 
which are passed to a method which returns a collection of processed strings. 
The input strings may be any length and can contain any character. 
Output strings must not be null or empty string, should be truncated 
to max length of 15 chars, and contiguous duplicate characters in the 
same case should  be reduced to a single character in the same case. 
Dollar sign ($) should be replaced with a pound sign (£), 
and underscores (_) and number 4 should be removed. Code should be test-driven, 
efficient, re-usable and loosely coupled. The returned collection must not be null.

Example input string:  AAAc91%cWwWkLq$1ci3_848v3d__K

When you have finished, please only send back the C# source (.cs) files for the code and tests. Do not include .sln, .csproj, .config or binary files.

