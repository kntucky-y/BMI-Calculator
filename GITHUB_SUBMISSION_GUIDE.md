# How to Submit to GitHub

Follow these steps to create a GitHub repository and submit your BMI Calculator project:

## Step 1: Create a GitHub Repository

1. Go to [GitHub](https://github.com) and sign in (or create an account if you don't have one)
2. Click the "+" icon in the top right corner and select "New repository"
3. Name your repository (e.g., "BMI-Calculator-MAUI")
4. Add a description: "A cross-platform BMI Calculator built with .NET MAUI"
5. Choose "Public" visibility
6. **Do NOT check** "Initialize this repository with a README" (we already have one)
7. Click "Create repository"

## Step 2: Initialize Git in Your Local Project

Open PowerShell or Command Prompt in your project folder and run:

```powershell
# Navigate to your project directory
cd "f:\Codes\BMI Calculator"

# Initialize git repository
git init

# Add all files to staging
git add .

# Create your first commit
git commit -m "Initial commit: BMI Calculator .NET MAUI app"
```

## Step 3: Connect to GitHub and Push

Replace `YOUR_USERNAME` and `YOUR_REPO_NAME` with your actual GitHub username and repository name:

```powershell
# Add GitHub repository as remote
git remote add origin https://github.com/YOUR_USERNAME/YOUR_REPO_NAME.git

# Rename branch to main (if needed)
git branch -M main

# Push to GitHub
git push -u origin main
```

### Alternative: Using GitHub CLI

If you have GitHub CLI installed:

```powershell
# Login to GitHub
gh auth login

# Create repository and push in one command
gh repo create BMI-Calculator-MAUI --public --source=. --push
```

## Step 4: Verify Your Repository

1. Go to your GitHub repository URL: `https://github.com/YOUR_USERNAME/YOUR_REPO_NAME`
2. Verify that all files are uploaded
3. Check that the README.md displays correctly
4. **Copy the repository URL** - this is what you'll submit

## Step 5: Submit the Link

Submit this URL to your instructor:
```
https://github.com/YOUR_USERNAME/YOUR_REPO_NAME
```

## Troubleshooting

### If you get authentication errors:

**Option 1: Use Personal Access Token**
1. Go to GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)
2. Generate new token with `repo` permissions
3. Use the token as your password when pushing

**Option 2: Use SSH**
```powershell
# Generate SSH key
ssh-keygen -t ed25519 -C "your_email@example.com"

# Add SSH key to GitHub (Settings → SSH and GPG keys)
# Then use SSH URL instead:
git remote set-url origin git@github.com:YOUR_USERNAME/YOUR_REPO_NAME.git
```

### If files are too large:

The .gitignore file should already exclude build folders. If you still have issues:
```powershell
# Remove large files from git
git rm -r --cached bin obj
git commit -m "Remove build artifacts"
git push
```

## Making Updates Later

After making changes to your code:

```powershell
git add .
git commit -m "Description of your changes"
git push
```

## Additional Resources

- [GitHub Docs - Getting Started](https://docs.github.com/en/get-started)
- [Git Basics Tutorial](https://git-scm.com/book/en/v2/Getting-Started-Git-Basics)
- [Visual Studio GitHub Integration](https://learn.microsoft.com/en-us/visualstudio/version-control/git-with-visual-studio)

## Tips for a Good Submission

1. ✅ Make sure README.md is complete and well-formatted
2. ✅ Ensure all necessary files are committed
3. ✅ Test that the repository can be cloned and built
4. ✅ Add a screenshot of the running app to README (optional but impressive)
5. ✅ Make the repository public so your instructor can access it

Good luck with your submission! 🚀
