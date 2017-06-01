FROM fedora:24
MAINTAINER Eric Missimer <missimer@gmail.com>

WORKDIR b-plus-plus

RUN useradd dev

RUN dnf install -y yum-utils
RUN rpm --import "http://keyserver.ubuntu.com/pks/lookup?op=get&search=0x3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF"
RUN yum-config-manager --add-repo http://download.mono-project.com/repo/centos7/
RUN dnf install -y make gcc java-1.8.0-openjdk mono-complete-4.6.1.5-0.xamarin.1 monodevelop-5.10.0.871-0.xamarin.2 nuget-2.12+mono-0.xamarin.1
