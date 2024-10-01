# IronFE

[![.NET](https://github.com/resistiv/IronFE/actions/workflows/dotnet.yml/badge.svg)](https://github.com/resistiv/IronFE/actions/workflows/dotnet.yml)
[![GitHub License](https://img.shields.io/github/license/resistiv/IronFE)](https://github.com/resistiv/IronFE/blob/master/LICENSE)
[![Ko-fi](https://img.shields.io/badge/Ko--fi-F16061?logo=ko-fi&logoColor=white)](https://ko-fi.com/resistiv)


IronFE is a .NET library for parsing and extracting files. Its implementation focuses on a combination of video game file formats and generally old or obscure transport formats.

IronFE is currently under active development, without a solidified public API. Until initial development is completed and tested to a fair degree, the library will remain as [v0.0.0](https://semver.org/#spec-item-4).

## Background
This library was created to isolate [KNFE](https://github.com/resistiv/KNFE)'s backend in an attempt to detangle the backend from the frontend. In doing so, several goals were identified:
* Easier usage & adaptability for end users
* Maintain a lightweight memory footprint
* Non-copyrighted, extensive unit testing

## Planned Functionality
- [X] DecodingStream as a derived class of Stream to allow for standardized usage
- [ ] Seeking on DecodingStream to allow for proper support of nested encodings
- [ ] File format identification based on file data patterns
- [ ] Unified common DecodingStream variants via base classes (e.g. LzssDecodingStream with support for different parameters)
- [ ] Image format identification and support

## License
This project is licensed under the [MIT License](LICENSE).
