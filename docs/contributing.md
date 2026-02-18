# 🆘 Contributing

Changes are welcome! Please read the following advice before submitting a new pull request:

- Search previous [pull requests] before adding a new one, as yours may be a duplicate.
- Create an individual pull request for each group of related functionality.
- Make sure your editor respects the `.editorconfig` [settings][editorconfig].
- Take a look through the source code and try and match its coding style to your submission.
- Add unit tests where possible, and run them using `just test` before submitting.
- Versioning is automated via [MinVer] and [SemVer] git tags — you do not need to edit the csproj version. To release, push a `v`-prefixed tag (e.g. `v10.2.0`) and CI will publish to NuGet.
- Finally: let's try and keep this professional, and fun if possible! For more information, see the [Contributor Covenant].

## Commit messages

This project uses [Conventional Commits]. Each commit message must have a
structured prefix so that changes are machine-readable and a changelog can be
generated automatically.

```text
<type>(<optional scope>): <description>
```

Common types:

| Type | When to use |
| --- | --- |
| `feat` | A new feature or extension method |
| `fix` | A bug fix |
| `docs` | Documentation-only changes |
| `refactor` | Code changes that neither add a feature nor fix a bug |
| `test` | Adding or correcting tests |
| `chore` | Maintenance (dependency bumps, tooling, CI) |

A `!` after the type (e.g. `feat!:`) or a `BREAKING CHANGE:` footer indicates a
breaking API change and will trigger a major version bump.

Thanks for your help!

[Contributor Covenant]: https://www.contributor-covenant.org/
[Conventional Commits]: https://www.conventionalcommits.org/
[editorconfig]: http://editorconfig.org/
[MinVer]: https://github.com/adamralph/minver
[pull requests]: https://github.com/WhatIsHeDoing/WhatIsHeDoing.Core/pulls
[SemVer]: http://semver.org/
