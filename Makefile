ANTLR_DIR=antlr
ANTLR=antlr-4.5.3-complete.jar
ANTLR_LINK=http://www.antlr.org/download/$(ANTLR)

VERSION=Debug|x86

.PHONY: antlr
.PHONY: bplusplus
.PHONY: debug
.PHONY: release

all:
	$(MAKE) antlr
	$(MAKE) bplusplus

debug:
	$(MAKE) all VERSION="Debug|x86"

release:
	$(MAKE) all VERSION="Release|x86"

antlr: $(ANTLR_DIR)/$(ANTLR)

$(ANTLR_DIR)/$(ANTLR):
	mkdir -p $(dir $@)
	cd $(dir $@); wget $(ANTLR_LINK)

bplusplus:
	mdtool build --target:Build --configuration:"$(VERSION)" bplusplus.sln

clean:
	mdtool build --target:Clean --configuration:"Debug|x86" bplusplus.sln
	mdtool build --target:Clean --configuration:"Release|x86" bplusplus.sln
	rm -rf compiler/bin
	find -name "*~" -delete
	rm -rf antlr
