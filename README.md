# StringParser
A project that parses the string from a text file and counts the number of unique words.

## Instructions

1. Navigate to [repo](https://github.com/foreign-key/StringParser)
2. Clone locally using
   `$ git clone https://github.com/foreign-key/StringParser.git` or download ZIP file
3. Open and run the solution
4. Enjoy!

## Discussion

I used the following technologies: C# and .Net Core 3.1.

## Requirements

#### Problem

Write a console program that counts the number of unique words in a specified text file.
Words are delimited by the SPACE character ONLY. (ASCII decimal code 32).  
Other punctuation marks (like tab, comma, hyphen, semi-colon, etc) are NOT word delimiters.
Words are case-insensitive.

###### Examples

Words | Number of unique words
------------ | -------------
**_thought-provoking_** | single word, not two
**_John’s john_** | different words because SPACE is the only delimiter
**_There are five words here_** | 5 words
**_There’s still five words here_** | still 5 words
**_Five are there? there are;_** | still 5 words (are ≠ are; and there ≠ there?)

#### Results

Write the results into another text file in the following SPACE-separated format

```
<Unique-word-1> <count>
<Unique-word-2> <count>
...
```

The output must be sorted by count descending, and then by word descending.

It must accept two command line parameters:
1. A full path to the text file containing the words, e.g. `D:\temp\wordlist.txt`
2. A full path to your results file, e.g. `D:\temp\results.txt`
