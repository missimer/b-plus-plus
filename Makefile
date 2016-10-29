VERSION=Debug

COMPILER_TEST_RESULTS=TestResults/$(VERSION)/CompilerTests.xml

.PHONY: bplusplus
.PHONY: debug
.PHONY: release
.PHONY: tests

all: bplusplus

debug:
	$(MAKE) all VERSION=Debug

release:
	$(MAKE) all VERSION=Release

tests: $(COMPILER_TEST_RESULTS)

bplusplus:
	nuget restore bplusplus.sln
	mdtool build --target:Build --configuration:"$(VERSION)|x86" bplusplus.sln

$(COMPILER_TEST_RESULTS): bplusplus
	mkdir -p $(dir $@)
	nunit-console -xml:$@ CompilerTests/bin/$(VERSION)/CompilerTests.dll

clean:
	mdtool build --target:Clean --configuration:"Debug|x86" bplusplus.sln
	mdtool build --target:Clean --configuration:"Release|x86" bplusplus.sln
	rm -rf Compiler/bin CompilerTests/bin packages TestResults
	find -name "*~" -delete
