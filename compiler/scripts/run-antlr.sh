#!/bin/bash

if [[ grammar/BPP.g4 -nt src/grammar/BPPParser.cs ]] ; then
  java -jar ../antlr/antlr-4.5.3-complete.jar -no-listener -visitor -o src/ grammar/BPP.g4
fi

