#!/bin/bash

ERRNAME=../temp/err.txt
INNAME=../temp/input.txt
EXPNAME=../temp/expected.txt
OUTNAME=../temp/actual.txt

MAXLEN=80


# ---- SHOW_FILE ----
function show_file {
	while read data
	do
		LINELEN=$(echo $data | wc -c)
		if [ $LINELEN -gt $MAXLEN ]; then
			data=$(echo $data | cut -c 1-$MAXLEN)
			data="$data..."
		fi
		echo "         $data"
	done <$1
}


# ---- SHOW_DIFFS ----
function show_diffs {
	echo "      expected:"
	show_file $EXPNAME
	echo "      actual:"
	show_file $OUTNAME
}


# ---- RUN_TEST ----
function run_test {
	mono --debug solution.exe < $INNAME > $OUTNAME 2>&1
	if [ $? -ne 0 ]; then
		echo "   FAIL! -> runtime error!"
		echo "Output:"
		cat $OUTNAME
		return
	fi

	diff $EXPNAME $OUTNAME > /dev/null
	if [ $? -eq 0 ]; then
		echo "   Pass."
	else
		echo "   FAIL!"
		show_diffs
		cp $EXPNAME ../temp/$1-expected.txt
		cp $OUTNAME ../temp/$1-actual.txt
	fi
}


# ---- MAIN ----
function main {

	# Make sure the solution file exists...
	if [ ! -f solution.cs ]; then
		echo "solution.cs does not seem to exist!"
		exit 1
	fi

	# Make sure the tests file exists...
	if [ ! -f tests.dat ]; then
		echo "tests.dat does not seem to exist!"
		exit 1
	fi

	# Compile the solution...
	echo "...compiling..."
	mcs -debug -r:System.Numerics solution.cs

	if [ $? -ne 0 ]; then
		echo "Compilation FAILED!"
		exit 1
	fi

	# Process all the tests in the test file...
	OUTFILE=$ERRNAME
	while read line
	do
		if [[ $line == %* ]]; then
			echo $line > /dev/null
		elif [[ $line == "@@ STOP" ]]; then
			echo "-- STOP --"
			exit 0
		elif [[ $line == vvvv* ]]; then
			TESTNAME=$(echo $line | cut -d' ' -f 2)
			echo "==== $TESTNAME ===="
			OUTFILE=$INNAME
			rm -f $OUTFILE
		elif [[ $line == "----" ]]; then
			OUTFILE=$EXPNAME
			rm -f $OUTFILE
		elif [[ $line == ^^^^* ]]; then
			run_test $TESTNAME
			OUTFILE=$ERRNAME
		elif [[ ! -z $line ]]; then
			if [[ $line == @@* ]]; then
				INFILE=$(echo $line | cut -d' ' -f 2)
				cat $INFILE >> $OUTFILE
			else
				echo $line >> $OUTFILE
			fi
		fi
	done <tests.dat

	# Positive reinforcement
	echo "Done."
}

# Let's do it!
main

