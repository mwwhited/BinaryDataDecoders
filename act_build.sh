#!/bin/sh 
#-v 
#cd
#template='templates/reports/DisableXmlDocs.xslt'
#rm .github/workflows/codeql-analysis.yml
#echo -P ubuntu-latest=nektos/act-environments-ubuntu:18.04>.actrc
#
#for f in src/*/*.csproj; do
#	xsltproc $template $f >$f.tmp
#	mv $f.tmp $f
#done

git reset --hard HEAD
git checkout .
rm -rf .github/workflows/codeql-analysis.yml.junk
git pull
mv .github/workflows/codeql-analysis.yml .github/workflows/codeql-analysis.yml.junk
act

git reset --hard HEAD
git checkout .
rm -rf .github/workflows/codeql-analysis.yml.junk

