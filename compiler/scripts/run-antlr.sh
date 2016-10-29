#!/bin/bash

if [[ grammar/BPP.g4 -nt src/grammar/BPPParser.cs ]] ; then
  java -jar ../packages/Antlr4.4.5.3/tools/antlr4-csharp-4.5.3-complete.jar -no-listener -visitor -o src/ grammar/BPP.g4
fi
