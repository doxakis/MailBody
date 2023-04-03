# Changelog

All notable changes to this project will be documented in this file.

## 2.0.0

Added
- class: ContentElement, method: TryGetAttribute
- class: ContentElement, method: HasAttribute
- class: ContentElement, method: GetAttribute
- Support for .net standard 2.0 (in other words: .net core 2.0 or more recent versions OR .net framework 4.6.1 or more recent versions.)

Removed
- class: ContentElement, method: IsProperty (consider using TryGetAttribute and/or HasAttribute and/or GetAttribute. See the readme for the new usage patterns)
- Support for netstandard1.4, netstandard1.6, .net core before 2.0 and any .net framework version before 4.6.1

## 1.1.X Initial versions
