# Implementation notes
So I tried to keep to the 2 hours on this but went over a little.  It's obviously not finished - I called the work at around 2 1/2 hours.
There's no automated testing / unit testing, and it should go without saying that this shouldn't go into production without. Given the time constraints, I chose not to focus on that.

I did focus on building a decoupled solution, breaking out the file selection part from the ingestion part and then the display part.
Iterating on this would obviously finesse the solution, but hopefully you can see the intent.
I tend to get stuff working first and then iterate on making it better and in 2 1/2 hours, there's not much opportunity for iterating :). 

I followed the humphries path through to displaying the output but didn't get the megacorp injestion completed. Also the currency converter only returns what is passed in at the moment - it does no conversion.

This code will support the data as presented in the example but would likely not scale terribly well as most of the work is done in memory








# Planning / thought process

## Tasks:
- Import files
-- How to determine file format?  Example has 2 file formats, real life prob has many - I'll assume I just need to handle these 2 for now, but real app would need a way to map many formats. 
-- Prob use a factory to get a reader for each file type

# File Formats
## humphries
- csv, AUD
- identifier,desc,unit,costAUD
## mega
- json
- richer data type - only partial needed for output
##  Data Store?
-- track source currency 
-- write to unified storage for both or separate - maybe separate or perhaps a document store 
--- idexing? 
-- track incoming currency (- only convert on output - do we need to track xe at time of injestion? )
-- Schema
	--- SupplierId-Product Id
	--- Supplier
	-- id
	-- price
	-- description
	-- currency
	-- info


# Output
- iterates over data stores
- uses source currency to load converter

# Processing
Should the whole thing run unattended or wait for user input?
- Will scan a directory for files - load file loader for appropriate file or take directory - list files, allow user to choose file to input

So ...
- Step one
-- UX - Show file listing for directory
-- UX - User choose file for load
-- (File choice is validated? how ?csv and json only, maybe hard code to these file names for now?, or some logic at injestion point - shows report at end of load?) 
-- UX - user says 'done'

- Step two
-- load files into local data store 
-- document? 
-- file load maps PK( id, supplier, )
-- file upload validates that file is valid
-- shows result of load (invalid files, invalid records)

- Step 3
-- UX - List / exit
-- List - 
