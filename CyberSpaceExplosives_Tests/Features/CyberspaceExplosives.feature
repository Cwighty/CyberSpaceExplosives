Feature: CyberspaceExplosives

decompressing the input

@tag1
Scenario Outline: Decompressing
	Given the input <input>
	When decompressing the input
	Then we get <output> with a length of <length>
	Examples: 
	| input             | output             | length |
	| ADVENT            | ADVENT             | 6      |
	| A(1x5)BC          | ABBBBBC            | 7      |
	| (3x3)XYZ          | XYZXYZXYZ          | 9      |
	| A(2x2)BCD(2x2)EFG | ABCBCDEFEFG        | 11     |
	| (6x1)(1x3)A       | (1x3)A             | 6      |
	| X(8x2)(3x3)ABCY   | X(3x3)ABC(3x3)ABCY | 18     |
	| A(1x3)B(1x3)C     | ABBBCCC            | 7      |
