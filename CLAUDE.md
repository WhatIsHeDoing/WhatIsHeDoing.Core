# WhatIsHeDoing.Core — Claude context

## Project overview

A .NET library of extensions to core .NET functionality, published to NuGet as
`WhatIsHeDoing.Core`. Target framework: `net10.0`.

## Common commands

All day-to-day tasks are in the `justfile` and run via [just].

| Command              | What it does                                  |
| -------------------- | --------------------------------------------- |
| `just`               | Interactive menu of all recipes               |
| `just restore`       | Restore NuGet dependencies                    |
| `just build`         | Debug build                                   |
| `just test`          | Debug test run                                |
| `just build_release` | Release build                                 |
| `just test_release`  | Release test run                              |
| `just pack`          | Pack NuGet package to `./nuget/`              |
| `just ci`            | Full CI sequence: release build → test → pack |
| `just outdated`      | Upgrade all NuGet dependencies                |
| `just docs`          | Build and serve docs locally with docfx       |

## Versioning

Versions are managed automatically by [MinVer] — do **not** set `<Version>` or
`<PackageVersion>` manually in the csproj.

- MinVer is configured with `<MinVerTagPrefix>v</MinVerTagPrefix>`, so it reads
  `v*` git tags (e.g. `v10.1.0`).
- On any commit that is not directly tagged, MinVer produces a pre-release
  version such as `10.1.0-alpha.0.3` (height since the last tag).

## Release process

1. Merge all changes to the `live` branch.
2. Create and push a `v`-prefixed tag:

   ```sh
   git tag v10.2.0
   git push origin v10.2.0
   ```

3. The CI pipeline detects the tag, runs the full build + tests, packs the
   project, and publishes to NuGet automatically.

Docs are only regenerated on pushes to `live` (not on tag builds).

## Commit messages

This project follows [Conventional Commits]. Every commit must be prefixed:

```txt
<type>(<optional scope>): <description>
```

Common types: `feat`, `fix`, `docs`, `refactor`, `test`, `chore`.
Use `feat!:` or a `BREAKING CHANGE:` footer for breaking changes.

## Package management

All NuGet package versions are centralised in [Directory.Packages.props] — do
not add `Version="..."` attributes to individual `<PackageReference>` elements.

## Code style

- `.editorconfig` is the source of truth for formatting.
- `.gitattributes` enforces LF line endings for all text files.
- `TreatWarningsAsErrors` is enabled — all warnings must be resolved.
- `Nullable` is enabled — null-safety must be maintained.

## CI/CD

| Workflow                 | Trigger                                | Key actions                                                                       |
| ------------------------ | -------------------------------------- | --------------------------------------------------------------------------------- |
| `build.yml`              | push to `live`, `v*` tags, PRs, manual | Build → test → coverage → pack; publish NuGet on `v*` tags; deploy docs on `live` |
| `codeql.yml`             | push/PR to `live`, monthly schedule    | CodeQL security analysis                                                          |
| `dependabot-approve.yml` | Dependabot PRs                         | Build, test, auto-approve, squash-merge                                           |

[just]: https://just.systems/
[MinVer]: https://github.com/adamralph/minver
[Conventional Commits]: https://www.conventionalcommits.org/
[Directory.Packages.props]: Directory.Packages.props
