var path = require('path'),
	clean = require('gulp-clean'),
	gulp = require('gulp');

var wwwroot = path.resolve(__dirname, "wwwroot");
var libroot = path.resolve(__dirname, "./node_modules");


var srcPaths = {
	css: [
		path.resolve(libroot, 'bootstrap-icons/font/bootstrap-icons.css')
	],

	fonts: [
		path.resolve(libroot, 'bootstrap-icons/font/fonts/bootstrap-icons.woff2'),
		path.resolve(libroot, 'bootstrap-icons/font/fonts/bootstrap-icons.woff')
	]
};


var destPaths = {
	css: path.resolve(wwwroot, 'css'),
	fonts: path.resolve(wwwroot, 'css/fonts')
};


gulp.task('clean', () => {
	return gulp.src(
		[path.resolve(wwwroot, 'css/**'), path.resolve(wwwroot, 'js/**'), path.resolve(wwwroot, 'lib/**')])
		.pipe(clean());
});

gulp.task('css', () => {
	return gulp.src(srcPaths.css)
		.pipe(gulp.dest(destPaths.css));
});

gulp.task('fonts', () => {
	return gulp.src(srcPaths.fonts)
		.pipe(gulp.dest(destPaths.fonts));
});

gulp.task('cleanup', gulp.series(['clean']));
gulp.task('default', gulp.series(['css'], ['fonts']));