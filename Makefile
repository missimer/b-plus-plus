VERSION=Debug|x86

.PHONY: bplusplus
.PHONY: debug
.PHONY: release

all:
	$(MAKE) bplusplus

debug:
	$(MAKE) all VERSION="Debug|x86"

release:
	$(MAKE) all VERSION="Release|x86"

bplusplus:
	mdtool build --target:Build --configuration:"$(VERSION)" bplusplus.sln

clean:
	mdtool build --target:Clean --configuration:"Debug|x86" bplusplus.sln
	mdtool build --target:Clean --configuration:"Release|x86" bplusplus.sln
	rm -rf compiler/src/grammar/*
	rm -rf compiler/bin
	find -name "*~" -delete
