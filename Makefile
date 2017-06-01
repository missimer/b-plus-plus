VERSION=Debug

COMPILER_TEST_RESULTS := TestResults/$(VERSION)/Compiler.Tests.xml
SHARPCOVER := SharpCover/Gaillard.SharpCover/bin/Debug/SharpCover.exe

.PHONY: bplusplus
.PHONY: debug
.PHONY: release
.PHONY: tests
.PHONY: sharpcover
.PHONY: coverage

all: bplusplus

debug:
	$(MAKE) all VERSION=Debug

release:
	$(MAKE) all VERSION=Release|x86

tests: $(COMPILER_TEST_RESULTS)

bplusplus:
	nuget restore bplusplus.sln
	mdtool build --target:Build --configuration:"$(VERSION)|x86" bplusplus.sln

$(COMPILER_TEST_RESULTS): bplusplus
	mkdir -p $(dir $@)
	nunit-console -xml:$@ Compiler.Tests/bin/$(VERSION)/Compiler.Tests.dll

sharpcover: $(SHARPCOVER)

$(SHARPCOVER):
	-cd SharpCover; bash ./build.sh

coverage: $(SHARPCOVER) bplusplus
	mono $(SHARPCOVER) instrument support/CodeCoverage/$(VERSION)/CodeCoverage.json
	nunit-console Compiler.Tests/bin/$(VERSION)/Compiler.Tests.dll
	-mono $(SHARPCOVER) check


clean:
	mdtool build --target:Clean --configuration:"Debug|x86" bplusplus.sln
	mdtool build --target:Clean --configuration:"Release|x86" bplusplus.sln
	xbuild /target:clean SharpCover/Gaillard.SharpCover/Program.csproj
	xbuild /target:clean SharpCover/Gaillard.SharpCover.Tests/ProgramTests.csproj
	rm -rf Compiler/bin Compiler.Tests/bin packages TestResults
	find -name "*~" -delete
