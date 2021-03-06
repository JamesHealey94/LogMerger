# LogMerger
Tool to merge multiple log files into one, outputting in chronological order

## Example usage
The first param is the output path, further params are taken as a list of input paths

- Each line in the input files should be in the following format: `yyyy-mm-dd hh:mm:ss.ms message`.
- Output is in the same format.
- Any files with lines not in this format are ignored (with a console message).
- Lines with the same timestamp are sorted alphabetically.

Here is an example:
- 2018-06-29 14:14:46.675 Hello Refract!
- 2018-06-29 14:15:00.123 Goodbye Refract!

## Run Tests
- `dotnet test`

## Docker
- `dotnet publish src/LogMerger.Runner -o output`
- `docker build -t log-merger .`
- `docker run -t log-merger output.txt input/test-input1.txt input/test-input2.txt`
- Console output will appear in logs, but output file may not be accessible

## Assumptions
- Would be simpler to just use awk, cat, sort, etc
- Assumes all log files are in the same time zone

## Further enhancements
- Reading the files could easily be done async
- Could use streams to write out files as they're being read, but would need extra logic to ensure chronological order was preserved
- DateTime format could be a param
- More testing around datetimes
- Could only ignore the bad lines rather than the whole file