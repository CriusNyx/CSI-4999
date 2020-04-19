pumlFiles=$(find $directory -type f -name "*.puml")

format="-tsvg"

for arg in $@; do
	if [[ $arg == "-tpng" ]]; then
		format="-tpng"
	fi
done

for file in $pumlFiles; do
	#remove ./ from begining of output
	output="$PWD/out/${file/.\//}"
	#get directory from output
	output=${output/.puml/}
	
	#echo $output
	echo Processing $file to $output as $format
	
	plantuml $file $format -o $output --overwrite
done
