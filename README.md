The purpose of this project is to set the date taken values on batches of scanned old photos. These lack the EXIF 'date taken' values needed to order the photos within a collection like Google Photos.

The mechanism is to point the console at a target directory and give it a start date and a number of days between photos. 
The app then iterates over all jpg files in the directory while adding date taken values and and incrementing the date taken by the number of days between photos.
